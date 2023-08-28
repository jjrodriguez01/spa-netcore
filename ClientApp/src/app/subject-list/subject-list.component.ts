import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Subject } from 'src/Subject';

@Component({
  selector: 'app-subject-list',
  templateUrl: './subject-list.component.html',
  styleUrls: ['./subject-list.component.css']
})
export class SubjectListComponent implements OnInit {

  private userId: string = '207f6021-bfa2-4d9c-9664-1588d021e17e';
  studentSubjects: Subject[] = [];
  partners: string[] = [];
  http: HttpClient;
  private url : string = "";
  
  constructor(http: HttpClient, @Inject('API_URL') baseUrl: string) 
  {
    this.url = baseUrl;
    this.http = http;
  }

  ngOnInit(): void {
    //traer materias del estudiante
    this.http.get<Subject[]>(this.url + 'Subject/byStudent?userId='+this.userId).subscribe({
      next: (v) => 
      {
        console.log(v);
        this.studentSubjects = v;
      },
      error: (e) => console.error(e),
      complete: () => console.info('complete') 
    });
  }

  viewPartners(id: number){
    this.http.get<string[]>(this.url + 'Subject/get-students?id='+id).subscribe({
      next: (v) => 
      {
        console.log(v);
        this.partners = v;
      },
      error: (e) => console.error(e),
      complete: () => console.info('complete') 
    });
  }
}
