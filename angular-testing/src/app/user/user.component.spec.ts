import {
  async,
  ComponentFixture,
  fakeAsync,
  TestBed,
  tick,
} from '@angular/core/testing';
import { DataService } from '../dataServices/data.service';

import { UserComponent } from './user.component';
import { UserService } from './user.service';

describe('UserComponent', () => {
  let component: UserComponent;
  let fixture: ComponentFixture<UserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [UserComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should use the user name from the service', () => {
    let userService = fixture.debugElement.injector.get(UserService);
    expect(userService.user.name).toEqual(component.user.name);
  });

  it('should display the user name if user is logged in', () => {
    let element = fixture.nativeElement;
    // Change login status to true;
    component.isLoggedIn = true;
    fixture.detectChanges();
    // See if paragraph shows username
    let p = element.querySelector('p').textContent;
    expect(p).toContain(component.user.name);
  });

  it("shouldn't fetch data successfully if not called asynchronously", () => {
    let dataService = fixture.debugElement.injector.get(DataService);
    let spy = spyOn(dataService, 'getDetails').and.returnValue(
      Promise.resolve('Data')
    );
    fixture.detectChanges();
    expect(component.data).toBe(undefined);
  });

  it('should fetch data successfully if called asynchronously', async(() => {
    let dataService = fixture.debugElement.injector.get(DataService);
    let spy = spyOn(dataService, 'getDetails').and.returnValue(
      Promise.resolve('Data')
    );
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      expect(component.data).toBe('Data');
    });
  }));

  // it('should fetch data successfully if called asynchronously (using fakeAsync)', fakeAsync(() => {
  //   let dataService = fixture.debugElement.injector.get(DataService);
  //   let spy = spyOn(dataService, 'getDetails').and.returnValue(
  //     Promise.resolve('Data')
  //   );
  //   fixture.detectChanges();
  //   tick();
  //   expect(component.data).toBe('Data');
  // }));

  // fakeAsync example
  describe('this test', () => {
    it(
      'looks async but is synchronous',
      <any>fakeAsync((): void => {
        let flag = false;
        setTimeout(() => {
          flag = true;
        }, 100);
        expect(flag).toBe(false);
        tick(50);
        expect(flag).toBe(false);
        tick(50);
        expect(flag).toBe(true);
      })
    );
  });
});
