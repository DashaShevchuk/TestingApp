import axios from "axios";
import {serverUrl} from '../../../config';

export default class TestPreviewService {
    static getTestsPreview(model) {
        return axios.post(`${serverUrl}api/user/get/available/${model.testId}`,model)
    };
}