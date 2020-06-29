import {
  Component,
  HostBinding,
  AfterViewInit,
} from '@angular/core';
import { fromEvent } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

@Component({
  selector: 'app-routes',
  templateUrl: 'routes.component.html',
})
export class RoutesComponent implements AfterViewInit {
  @HostBinding('class.mx-auto')
  marginAuto = true;

  smallScreen = window.innerWidth < 992;

  ngAfterViewInit() {
    fromEvent(window, 'resize')
      .pipe(debounceTime(150))
      .subscribe(() => {
        this.smallScreen = window.innerWidth < 992;
      });
  }
}
