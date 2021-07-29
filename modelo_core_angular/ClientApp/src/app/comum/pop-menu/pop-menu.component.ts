import { Component, HostListener, OnInit } from '@angular/core';

@Component({
  selector: 'app-pop-menu',
  templateUrl: './pop-menu.component.html',
  styleUrls: ['./pop-menu.component.css']
})
export class PopMenuComponent implements OnInit {
  isShown = false;
  constructor() { }

  ngOnInit(): void {
  }

  @HostListener('mouseleave')
  ocultarLeave() {
    this.isShown = false;
  }

  @HostListener('click')
  ocultarClick() {
    this.isShown = false;
  }

  @HostListener('mouseover')
  exibirMenu() {
    this.isShown = true;
  }

}
