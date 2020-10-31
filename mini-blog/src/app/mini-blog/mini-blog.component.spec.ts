import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';

import { MiniBlogComponent } from './mini-blog.component';

describe('MiniBlogComponent', () => {
  let component: MiniBlogComponent;
  let fixture: ComponentFixture<MiniBlogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [MiniBlogComponent],
      imports: [FormsModule],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MiniBlogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render blog', () => {
    // Write new blog
    let title = 'This is a blog';
    let description = 'blog description goes here.';
    component.blog = { title, description };
    fixture.detectChanges();

    // Check both title and description
    let ne = fixture.nativeElement;
    expect(ne.querySelector('.blog-title').textContent).toEqual(title);
    expect(ne.querySelector('.blog-description').textContent).toEqual(
      description
    );
  });
});
