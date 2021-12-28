import { ICourse } from "./course";

export interface ICourseBasket{
    userEmail: String,
    totalPrice:Number,
    items: ICourse[],
}