import { Routes } from '@angular/router';
import { Component, OnInit, Injectable } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

@Injectable()
export class SandHttpService {
    constructor(private http: HttpClient) {
    }
    public get(url: string, params: any, callback: any):any {
        this.http.get(url,{params:params}).subscribe(callback);
        ;
    }
}