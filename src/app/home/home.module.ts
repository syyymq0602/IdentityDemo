import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { NzButtonModule, NzCardModule, NzTypographyModule } from 'ng-zorro-antd';
import { NzSpaceModule } from 'ng-zorro-antd/space';

@NgModule({
  declarations: [HomeComponent],
  imports: [
    SharedModule,
    HomeRoutingModule,
    NzCardModule,
    NzTypographyModule,
    NzButtonModule,
    NzSpaceModule
  ]
})
export class HomeModule {
}
