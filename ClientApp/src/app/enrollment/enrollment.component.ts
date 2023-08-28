import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { async, map, take } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';
import { Subject } from 'src/Subject';
import { AuthorizeService } from 'src/api-authorization/authorize.service';

@Component({
  selector: 'app-enrollment',
  templateUrl: './enrollment.component.html',
  styleUrls: ['./enrollment.component.css']
})
export class EnrollmentComponent implements OnInit {
  subjects: Subject[] = [];
  private url : string = "";
  http: HttpClient;
  responseMensaje: string | null = null;
  public userName?: Observable<string | null | undefined>;
  
  constructor(http: HttpClient, @Inject('API_URL') baseUrl: string,private authorizeService: AuthorizeService) 
  {
    this.url = baseUrl;
    this.http = http;
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
  }

  ngOnInit(): void {
    //mover a un servicio si hay tiempo
    //traer todos los cursos
    this.http.get<Subject[]>(this.url + 'Subject').subscribe({
      next: (v) => 
      {
        console.log(v);
        this.subjects = v;
      },
      error: (e) => console.error(e),
      complete: () => console.info('complete') 
    });
  }

  enroll(id: number){
    this.userName?.subscribe(userName => {
      if (userName !== null && userName !== undefined) {
        // Aquí puedes hacer algo con el valor de userName
        console.log(userName);
        this.http.get<UserId>(this.url+'User/get-userid?userName='+userName).subscribe(data => {
        // Maneja la respuesta aquí, por ejemplo, asignando los datos a una variable
        console.log(data.userId);
        const BODY = {userId: data.userId, subjectId: id};
        this.http.post(this.url + 'Subject/enroll', BODY)
        .subscribe(
          (response) => {
            console.log(response);
            this.responseMensaje = "Materia registrada";
          },
          (error) => {
            if (error.status === 400) {
              console.error('Estado 400 - Bad Request:', error.error);
              this.responseMensaje = error.error;
              // Aquí puedes trabajar con el mensaje de error 'error.error'
              // para realizar las acciones que necesites en caso de un estado 400.
            } else {
              console.error('Error:', error);
              // Manejar otros errores si es necesario.
            }
          },
          () => {
            console.info('complete');
          }
        );
        });
      } else {
        // Handle el caso en el que userName sea null o undefined
        console.log('userName es null o undefined');
      }
    }).unsubscribe();
  }
}

interface UserId {
  userId: string
}