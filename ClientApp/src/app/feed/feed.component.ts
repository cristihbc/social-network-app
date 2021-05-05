import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { BurritoService } from '../burrito.service';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.css']
})
export class FeedComponent implements OnInit {
  writer: string;
  url: string;
  writtenPosts: Post[];
  profileUrl: string;

  constructor(
    private burritoService: BurritoService,
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
    ) {
    if (localStorage.length > 0) {
      this.writer = localStorage.getItem("logged");
    }
    this.writer = this.burritoService.getUsername();
    this.url = baseUrl + 'api/post';
    this.profileUrl = baseUrl + 'profile';

    console.log(this.writer);
  
    this.retrievePosts();
  }

  ngOnInit() {
  }

  share(content) {
    console.log(content);

    this.http.post(this.url, {
      "id": 2,
      "username": localStorage.getItem("logged"),
      "content": content
    }).subscribe((result) => {
      console.log("posted");
    });

    window.location.reload();
  }

  retrievePosts() {
    this.http.get<Post[]>(this.url).subscribe(result => {
      this.writtenPosts = result;
    });
  }

  delete(postId, postUsername) {
    this.http.delete(this.url + `/${postId}?username=${postUsername}`).subscribe(result => {
      console.log("Deleted the post");
    });

    window.location.reload();
  }
}

interface Post {
  id: number,
  username: string,
  content: string,
  date: string
}