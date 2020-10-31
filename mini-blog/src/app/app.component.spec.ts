import { TestBed, async, ComponentFixture } from '@angular/core/testing';
import { FormsModule, NgForm } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';
import { MiniBlogFormComponent } from './mini-blog-form/mini-blog-form.component';
import { MiniBlogComponent } from './mini-blog/mini-blog.component';

describe('AppComponent', () => {
  let app: AppComponent;
  let fixture: ComponentFixture<AppComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule, FormsModule],
      declarations: [AppComponent, MiniBlogComponent, MiniBlogFormComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppComponent);
    app = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the app', () => {
    expect(app).toBeTruthy();
  });

  it(`should have the default title`, () => {
    expect(app.title).toEqual('Welcome to the mini-blog site.');
  });

  it('should render title', () => {
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('#title').textContent).toContain(
      'Welcome to the mini-blog site.'
    );
  });

  it('Should add blog', () => {
    let title = 'Test blog';
    let description = 'This is a test blog.';
    app.onAddBlog({ title, description });
    expect(app.blogs[0].title).toEqual(title);
    expect(app.blogs[0].description).toEqual(description);
  });
});
