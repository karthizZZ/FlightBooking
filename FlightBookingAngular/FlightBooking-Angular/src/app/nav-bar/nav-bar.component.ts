import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from '../service/token-storage.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  IsAdmin:boolean;
  constructor(private tokenStorageService: TokenStorageService) { }

  ngOnInit(): void {
            this.IsAdmin = this.tokenStorageService.getUser().isAdminUser;
  }
  logout(): void {
    this.tokenStorageService.signOut();
    window.location.reload();
  }
}
