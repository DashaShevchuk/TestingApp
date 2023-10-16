import axios from "axios";
import {serverUrl} from '../../../config';

export default class TestService {
    static getTest(model) {
        return axios.post(`${serverUrl}api/user/${model.testId}`,model)
    };
}