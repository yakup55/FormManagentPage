import axios from "axios";

class UserService {
  constructor() {
    this.baseUrl = `${process.env.REACT_APP_BASEURL}/User`;
  }
  async addUser(user) {
    const url = `${this.baseUrl}/CreateUser`;
    return await axios
      .post(url, user)
      .then((resp) => {
        return { status: resp.status, data: resp.data };
      })
      .catch((err) => {
        return { status: err.response.status };
      });
  }
  async getByUserMail(email) {
    const url = `${this.baseUrl}/GetByUserEmail/${email}`;
    return await axios.get(url).then((resp) => resp.data);
  }
  async getByUser(id) {
    const url = `${this.baseUrl}/GetByUser/${id}`;
    return await axios.get(url).then((resp) => resp.data);
  }
}
export default UserService;
