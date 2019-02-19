import axios from 'axios';
import { take, call, put, fork } from 'redux-saga/effects';
import * as c from '../constants/constant';
import {fetchOutput} from '../actions/action-usps';

export function* sagaCallUSPS(){
    while (true) {
      const {payload} = yield take(c.CALL_API);
      try {
        let url = '';
        switch (payload.mode) {
            case 1:
                url = 'usps-services/address-verify';       
                break;
            case 2:
                url = 'usps-services/zip-code-lookup';
                break;
            case 3:
                url = 'usps-services/city-state-lookup';
                break;
        }
  
        let res = yield call(axios.post, url, payload);
        if(res.data.status == "success"){
          yield put(fetchOutput(res.data.data));
        }else{
          alert('Something wrong happened!');
        }
      } catch (error) {
        console.log(error);
      }
    }
  }