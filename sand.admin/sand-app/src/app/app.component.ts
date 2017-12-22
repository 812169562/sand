import { Component,ViewEncapsulation,OnInit, Inject,Injectable } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { SystemRouterComponent } from './systemrouter.component';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
@Injectable()
export class AppComponent implements OnInit{
  constructor(private router:Router,private  sysRouter:SystemRouterComponent){

  }
    ngOnInit(){
    }
}
