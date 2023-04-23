import { object, string, number } from "yup";

export const validationSchema = object({
  firstName: string().required("Bu Alan Zorunlu"),
  userName: string().required("Bu Alan Zorunlu"),
  lastName: string().required("Bu Alan Zorunlu"),
  age: number().required().positive().integer(),
  password: string().required("Bu Alan Zorunlu"),
});
