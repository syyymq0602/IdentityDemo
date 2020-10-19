import { Component, OnInit } from '@angular/core';
import { NzTableModule } from 'ng-zorro-antd/table';

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
      paraName: '泵轴转速',
      numericalValue: 1200,
      expand: false,
      statusBar: '正常',
      description: 'H1：1600rpm；H2:1750rpm（注：其中L1为低限，L2为低低限；H1为高限，H2为高高限）'
    },
    {
      id: 2,
      paraName: '泵轴位移',
      numericalValue: 70,
      expand: false,
      statusBar: '正常',
      description: 'H1：100.0μm; H2: 200.0μm'
    },
    {
      id: 3,
      paraName: '电机轴位移',
      numericalValue: 60,
      expand: false,
      statusBar: '良好',
      description: 'H1：100.0μm; H2: 200.0μm'
    },
    {
      id: 4,
      paraName: '电机顶部机架振动',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: 'H1：35μm; H2: 70μm'
    },
    {
      id: 5,
      paraName: '电机下部机架振动',
      numericalValue: 40,
      expand: false,
      statusBar: '良好',
      description: 'H1：35μm; H2: 70μm'
    },
    {
      id: 6,
      paraName: '负荷',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 7,
      paraName: '电机空冷温度U项',
      numericalValue: 105,
      expand: false,
      statusBar: '良好',
      description: 'H1：130℃; H2: 140℃'
    },
    {
      id: 8,
      paraName: '电机空冷温度V项',
      numericalValue: 90,
      expand: false,
      statusBar: '良好',
      description: 'H1：130℃; H2: 140℃'
    },
    {
      id: 9,
      paraName: '电机空冷温度W项',
      numericalValue: 100,
      expand: false,
      statusBar: '良好',
      description: 'H1：130℃; H2: 140℃'
    },
    {
      id: 10,
      paraName: '上导轴瓦温度',
      numericalValue: 110,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 11,
      paraName: '上推力瓦温度',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 12,
      paraName: '下推力瓦温度',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 13,
      paraName: '电机上导轴承温度',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 14,
      paraName: '下导轴承进口润滑油温',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 15,
      paraName: '上导轴承进口润滑油温',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 16,
      paraName: '油冷器进口润滑油温',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 17,
      paraName: '油冷器出口润滑油温',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 18,
      paraName: '下导轴承进口润滑油温',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 19,
      paraName: '下导轴承出口润滑油温',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 20,
      paraName: '空冷器进口空气温度',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 21,
      paraName: '空冷器出口空气温度',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 22,
      paraName: '空冷器进口冷却水温度',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 23,
      paraName: '空冷器出口冷却水温度',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 24,
      paraName: '定子电流',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 25,
      paraName: '电机上部油箱油位',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 26,
      paraName: '电机下部油箱油位',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 27,
      paraName: '润滑油流量',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 28,
      paraName: '空冷器冷却水流量',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 29,
      paraName: '油冷器冷却水流量',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 30,
      paraName: '供油管路压力',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 31,
      paraName: '二三级轴封压力',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 32,
      paraName: '高低压泄露压力',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 33,
      paraName: '轴封注入水压力',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 34,
      paraName: '轴封密封前温度',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 35,
      paraName: '轴封注入流量',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 36,
      paraName: '高低压泄露流量',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 37,
      paraName: '高压冷却器冷却水流量',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 38,
      paraName: '高压冷却器冷却水进出口温度',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 39,
      paraName: '轴封注入水温度',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 40,
      paraName: '高低压泄露温度',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    },
    {
      id: 41,
      paraName: '密封座位置',
      numericalValue: 32,
      expand: false,
      statusBar: '良好',
      description: '对于该参数的描述'
    }
  ];
}
