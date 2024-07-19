import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu-global',
  templateUrl: './menu-global.component.html',
  styleUrls: ['./menu-global.component.scss']
})
export class MenuGlobalComponent {
  constructor(private router: Router) { }

  onClose(): void {
    localStorage.removeItem('currentUser');
    this.router.navigate(['/login']);
  }
}