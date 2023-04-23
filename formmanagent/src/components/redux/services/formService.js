import axios from "axios";

class FormService {
  constructor() {
    this.baseUrl = `${process.env.REACT_APP_BASEURL}/Form`;
  }
  async getFormList() {
    const url = `${this.baseUrl}/GetAllForm`;
    return await axios.get(url).then((resp) => resp.data);
  }
  async getByForm(id) {
    const url = `${this.baseUrl}/GetByForm/${id}`;
    return await axios.get(url).then((resp) => resp.data);
  }
  async addForm(form) {
    const url = `${this.baseUrl}/AddForm`;
    return await axios.post(url, form).then((resp) => resp.data);
  }
  async updateForm(form) {
    const url = `${this.baseUrl}/UpdateForm`;
    return await axios.put(url, form).then((resp) => resp.data);
  }
  async deleteForm(id) {
    const url = `${this.baseUrl}/DeleteForm/${id}`;
    return await axios.delete(url).then((resp) => resp.data);
  }
  async userForm(userId) {
    const url = `${this.baseUrl}/FormUser/${userId}`;
    return await axios.get(url).then((resp) => resp.data);
  }
  async searchForm(search){
    const url = `${this.baseUrl}/SearchForm/${search}`;
    return await axios.get(url).then((resp)=>resp.data);
  }
}
export default FormService;
