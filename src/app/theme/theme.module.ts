import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LogoComponent } from './components';

@NgModule({
  declarations: [LogoComponent],
  imports: [
    CommonModule,
  ],
  exports: [LogoComponent]
})
export class ThemeModule { }
