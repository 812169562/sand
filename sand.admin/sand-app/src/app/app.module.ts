import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { AppComponent } from './app.component';
import { RouterModule, PreloadAllModules } from '@angular/router';
import { routes,SystemRouterComponent } from './systemrouter.component';
import { SandHttpService } from './tools/sandHttp.service'
import { DicComponent } from './admin-dic/dic.component';

@NgModule({
  declarations: [
    AppComponent,
    DicComponent
  ],
  providers:[SystemRouterComponent,SandHttpService],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NgZorroAntdModule.forRoot(),
    RouterModule.forRoot(routes, { useHash: true, preloadingStrategy: PreloadAllModules }),
    RouterModule.forChild([{path: 'dic',  component: DicComponent }])
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }