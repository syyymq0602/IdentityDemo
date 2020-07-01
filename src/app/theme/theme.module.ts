import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LogoComponent, RoutesComponent } from './components';
import { SharedModule } from '../shared/shared.module';
import { NzMenuModule } from 'ng-zorro-antd';

@NgModule({
  declarations: [LogoComponent,RoutesComponent],
  imports: [
    CommonModule,
    SharedModule,
    NzMenuModule
  ],
  exports: [LogoComponent,RoutesComponent]
})
export class ThemeModule { }
