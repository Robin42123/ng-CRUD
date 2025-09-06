import { CommonModule } from '@angular/common';
import { Component, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { Student, StudentService } from '../../services/student';

@Component({
  selector: 'app-student-edit',
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './student-edit.html',
  styleUrl: './student-edit.css'
})
export class StudentEdit implements OnInit {
  student = signal<Student>({ id: 0, name: '', class: '' });

  constructor(private route: ActivatedRoute, private router: Router, private service: StudentService) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    if (id) {
      this.service.getStudentById(id).subscribe({
        next: (data) => this.student.set(data),
        error: (err) => console.error('Error loading student', err)
      })
    }

  }

  save() {
    this.service.updateStudent(this.student()).subscribe({
      next: () => {
        alert("Student Updated successfully");
        this.router.navigate(['/students']);
      },
      error: (err) => console.error('Error Saving Student', err)
    })
  }

}
