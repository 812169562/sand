import { Component, OnInit, Injectable } from '@angular/core';

@Component({
    selector: 'app-root',
    templateUrl: './dic.component.html',
})

@Injectable()
export class DicComponent implements OnInit {
    public BindData = [];
    constructor() {

    }
    public ngOnInit() {
        this.BindData[0]= {name:"1",age:"2",address:"3",disabled:false,checked:true};
        this.BindData[1]= {name:"1",age:"2",address:"3",disabled:false,checked:true};
        this.BindData[2]= {name:"1",age:"2",address:"3",disabled:false,checked:true};
        this.BindData[3]= {name:"1",age:"2",address:"3",disabled:false,checked:false};
        this.BindData[4]= {name:"1",age:"2",address:"3",disabled:false,checked:false};
        this.BindData[5]= {name:"1",age:"2",address:"3",disabled:false,checked:false};
        this.BindData[6]= {name:"1",age:"2",address:"3",disabled:false,checked:false};
        this.BindData[7]= {name:"1",age:"2",address:"3",disabled:false,checked:false};
        this.BindData[8]= {name:"1",age:"2",address:"3",disabled:false,checked:false};
        this.BindData[9]= {name:"1",age:"2",address:"3",disabled:false,checked:false};
        this.BindData[10]= {name:"1",age:"2",address:"3",disabled:false,checked:false};
        this.BindData[11]= {name:"1",age:"2",address:"3",disabled:false,checked:false};
     }

     _allChecked = false;
     _indeterminate = false;
     _displayData = [];

     _displayDataChange($event) {
        this._displayData = $event;
        this._refreshStatus();
      }
    
      _refreshStatus() {
        const allChecked = this._displayData.every(value => value.disabled || value.checked);
        const allUnChecked = this._displayData.every(value => value.disabled || !value.checked);
        this._allChecked = allChecked;
        this._indeterminate = (!allChecked) && (!allUnChecked);
      }
    
      _checkAll(value) {
          debugger;
        if (value) {
          this._displayData.forEach(data => {
            if (!data.disabled) {
              data.checked = true;
            }
          });
        } else {
          this._displayData.forEach(data => data.checked = false);
        }
        this._refreshStatus();
      }
}