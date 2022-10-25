import {AxiosResponse} from "axios";
import {callApi} from "./axios.service";
import {AxiosMethodEnum} from "./config/axios.types";

export const postCamundaEngine = async (url: string, data: any): Promise<AxiosResponse<any>> => {
    return await callApi({
        url: url, method: AxiosMethodEnum.POST, data
    })
}