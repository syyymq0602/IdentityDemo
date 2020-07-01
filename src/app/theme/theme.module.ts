import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LogoComponent, RoutesComponent } from './components';
import { SharedModule } from '../shared/shared.module';
import { NzIconModule, NzLayoutModule, NzMenuModule } from 'ng-zorro-antd';
import { MainLayoutComponent } from './layouts';

@NgModule({
  declarations: [LogoComponent,RoutesComponent, MainLayoutComponent],
  imports: [
    CommonModule,
    SharedModule,
    NzMenuModule,
    NzIconModule,
    NzLayoutModule
  ],
  exports: [LogoComponent,RoutesComponent]
})
export class ThemeModule { }
