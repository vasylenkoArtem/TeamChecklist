import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-checklist',
  standalone: false,
  templateUrl: './checklist.component.html',
  styleUrl: './checklist.component.css'
})
export class ChecklistComponent {
  // constructor(private apiService: ChecklistsService) { }
  
  ngOnInit (): void {
    //   this.apiService.checklistsTypeIdGet$Plain$Response({typeId: ChecklistType.Morning})
    // .subscribe(x => console.log("response", x))

  }

  
}
