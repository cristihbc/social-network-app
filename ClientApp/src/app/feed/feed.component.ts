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
  comments: Map<number, Comment[]>;
  baseUrl: string;

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
    this.baseUrl = baseUrl;
    this.comments = new Map<number, Comment[]>();

    console.log(this.writer);
  
    this.retrievePosts();
  }

  ngOnInit() {
  }

  share(content) {
    console.log(content);

    if (localStorage.getItem("logged")) {
      this.http.post(this.url, {
        "id": 2,
        "username": localStorage.getItem("logged"),
        "content": content
      }).subscribe(result => {
        console.log("posted");
      });
    }
    else {
      console.error("Not logged");
    }

    window.location.reload();
  }

  retrievePosts() {
    this.http.get<Post[]>(this.url).subscribe(result => {
      this.writtenPosts = result;
    
      this.writtenPosts.forEach(it => {
        this.http.get<Comment[]>(this.baseUrl + `api/comment/post/${it.id}`).subscribe(result => {
          console.log(result);
          this.comments.set(it.id, result);
        });
      });

      console.log(this.comments);
    });
  }

  delete(postId, postUsername) {
    if (localStorage.getItem("logged")) {
      this.http.delete(this.url + `/${postId}?username=${postUsername}`).subscribe(result => {
        console.log("Deleted the post");
      });
    }
    else {
      console.error("Not logged");
    }

    window.location.reload();
  }

  writeComment(postid, content) {
    if (localStorage.getItem("logged")) {
      this.http.post(this.baseUrl + 'api/comment', {
        "postID": postid,
        "username": localStorage.getItem("logged"),
        "content": content
      }).subscribe(result => {
        console.log("commented");
      });
    }
    else {
      console.error("Not logged");
    }

    window.location.reload();
  }
}

interface Post {
  id: number,
  username: string,
  content: string,
  date: string
}

interface Comment {
  id: number,
  postID: number,
  username: string,
  content: string,
  date: string
}