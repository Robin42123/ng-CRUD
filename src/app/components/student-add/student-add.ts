import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule, Router } from '@angular/router';
import { Student, StudentService } from '../../services/student';

@Component({
  selector: 'app-student-add',
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './student-add.html',
  styleUrl: './student-add.css'
})
export class StudentAdd {
  student: Student = { id: 0, name: '', class: '' };

  constructor(private service: StudentService, private router: Router) { }

  save() {
    this.service.addStudent(this.student).subscribe({
      next: () => {
        alert('Student added successfully!');
        this.router.navigate(['/students']); // back to list
      },
      error: (err) => console.error('Error adding student', err)
    });
  }
}
