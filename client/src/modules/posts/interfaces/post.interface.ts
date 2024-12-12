export interface IPost {
  id: number;
  title: string;
  description: string;
  skills_offered: string[];
  skills_requested: string[];
  author: IAuthor;
  published_date: string;
  status: string;
  images: string[];
}

interface IAuthor {
  name: string;
  profile_img: string;
  headline: string;
}
