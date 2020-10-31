import { DebugElement, Input } from '@angular/core';
import {
  async,
  ComponentFixture,
  fakeAsync,
  TestBed,
  tick,
} from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { By } from '@angular/platform-browser';

import { MiniBlogFormComponent } from './mini-blog-form.component';

describe('MiniBlogFormComponent', () => {
  let component: MiniBlogFormComponent;
  let fixture: ComponentFixture<MiniBlogFormComponent>;
  let de: DebugElement;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [MiniBlogFormComponent],
      imports: [FormsModule],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MiniBlogFormComponent);
    component = fixture.componentInstance;
    de = fixture.debugElement;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should clear form after submit', fakeAsync(() => {
    let blog = { title: 'Random title', description: 'Description goes here' };
    // component.blog = blog;

    // Input fields
    // let inputField = ne.querySelector('input[name="title"]');

    let inputField = de.query(By.css('input[name="title"]')).nativeElement;
    inputField.value = blog.title;
    // de.query(By.css('input[name="title"]')).nativeElement.value = blog.description;
    inputField.dispatchEvent(new Event('input'));
    tick(100);
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      // expect(component.blog.title).toBe(blog.title);
      // expect(de.query(By.css('input[name="title"]')).nativeElement.value).toBe(
      //   blog.title
      // );
    });

    // Submit blog, fields should be cleared
    component.submitBlog();
    tick(100);
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      expect(de.query(By.css('input[name="title"]')).nativeElement.value).toBe(
        ''
      );
    });
  }));
});
