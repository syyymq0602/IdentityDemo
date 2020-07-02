import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LogoComponent, ProfileComponent, RoutesComponent, LoginComponent } from './components';
import { SharedModule } from '../shared/shared.module';
import { NzButtonModule, NzDropDownModule, NzIconModule, NzLayoutModule, NzMenuModule } from 'ng-zorro-antd';
import { MainLayoutComponent } from './layouts';

@NgModule({
  declarations: [LogoComponent,RoutesComponent, MainLayoutComponent, ProfileComponent, LoginComponent],
  imports: [
    CommonModule,
    SharedModule,
    NzMenuModule,
    NzIconModule,
    NzLayoutModule,
    NzButtonModule,
    NzDropDownModule
  ],
  exports: [LogoComponent,RoutesComponent, ProfileComponent]
})
export class ThemeModule { }
