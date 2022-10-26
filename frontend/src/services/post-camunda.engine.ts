import {AxiosResponse} from "axios";
import {callApi} from "./axios.service";
import {AxiosMethodEnum} from "./config/axios.types";
import {ProcessStats} from "../types/process-stats.types";

export const postCamundaEngine = async (url: string, data: any): Promise<AxiosResponse<ProcessStats[]>> => {
    return await callApi({
        url: url, method: AxiosMethodEnum.POST, data
    })
}