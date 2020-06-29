import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LogoComponent, RoutesComponent } from './components';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [LogoComponent,RoutesComponent],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [LogoComponent,RoutesComponent]
})
export class ThemeModule { }
