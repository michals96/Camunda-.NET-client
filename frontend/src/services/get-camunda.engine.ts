import {AxiosResponse} from "axios";
import {callApi} from "./axios.service";
import {AxiosMethodEnum} from "./config/axios.types";

export const getCamundaEngine = async ():Promise<AxiosResponse<any>> => {
    return await callApi({
        url: 'http://localhost:8080/engine-rest/process-definition/key/licensing-process/statistics',
        method: AxiosMethodEnum.GET
    })
}