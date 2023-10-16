import axios from "axios";
import {serverUrl} from '../../../config';

export default class AvailableTestsServices {
    static getTests() {
        return axios.get(`${serverUrl}api/user/get/available`)
    };
}