import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-real-time-param',
  templateUrl: './real-time-param.component.html',
  styleUrls: ['./real-time-param.component.scss']
})
export class RealTimeParamComponent implements OnInit {
  constructor() { }
  ngOnInit(): void {
  }

  expandSet = new Set<number>();
  onExpandChange(id: number, checked: boolean): void {
    if (checked) {
      this.expandSet.add(id);
    } else {
      this.expandSet.delete(id);
    }
  }
  listOfData = [
    {
      id: 1,
      paraName: 'Frame_vibration',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 2,
      paraName: 'Zero_speed_measurement',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 3,
      paraName: 'Left_lifting_oil_pressure',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 4,
      paraName: 'Right_lifting_oil_pressure',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    }
  ];

}
