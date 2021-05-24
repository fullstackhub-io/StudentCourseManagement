import { ICourse } from "./course";

export interface ICourseBasket{
    userEmail: String,
    totalPrice:number,
    items: ICourse[],
}