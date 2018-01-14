import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule,NoopAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule,Injectable } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { AppComponent } from './app.component';
import { RouterModule, PreloadAllModules } from '@angular/router';
import { routes,SystemRouterComponent } from './systemrouter.component';
import { SandHttpService } from './tools/sandHttp.service'
import { DicComponent } from './admin-dic/dic.component';
import { UserComponent } from './admin-users/users.component';
import { MatButtonModule,MatCommonModule} from '@angular/material'
import {OverlayContainer} from '@angular/cdk/overlay';
@NgModule({
  declarations: [
    AppComponent,
    DicComponent,
    UserComponent,
  ],
  providers:[SystemRouterComponent,SandHttpService],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NoopAnimationsModule,
    NgZorroAntdModule.forRoot(),
    RouterModule.forRoot(routes, { useHash: true, preloadingStrategy: PreloadAllModules }),
    MatButtonModule,
    MatCommonModule
    // RouterModule.forChild([{path: 'dic',  component: DicComponent },{path: 'users',  component: UserComponent }]),
  ],
  bootstrap: [AppComponent]
})
@Injectable()
export class AppModule { 
    constructor(private overlayContainer: OverlayContainer) {
      overlayContainer.getContainerElement().classList.add('unicorn-dark-theme');
  }
}