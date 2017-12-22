import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DicComponent } from './dic.component';

@NgModule({
  imports: [ RouterModule.forChild([
    { path: '', component: DicComponent }
  ]) ],
  exports: [ RouterModule ]
})
export class DicRoutingComponent {
}
