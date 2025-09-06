import { Routes } from '@angular/router';
import { StudentList } from './components/student-list/student-list';
import { StudentAdd } from './components/student-add/student-add';
import { StudentEdit } from './components/student-edit/student-edit';

export const routes: Routes = [
    { path: '', redirectTo: 'students', pathMatch: 'full' },
    { path: 'students', component: StudentList },
    { path: 'students/add', component: StudentAdd },
    { path: 'students/edit/:id', component: StudentEdit },
];
