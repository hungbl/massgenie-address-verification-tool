import axios from 'axios';
import { take, call, put, fork } from 'redux-saga/effects';
import * as c from '../constants/constant';
import {fetchOutput} from '../actions/action-usps';

export function* sagaCallUSPS(){
    while (true) {
      const {payload} = yield take(c.CALL_API);
      try {
        let url = '';
        let res = null;
        switch (payload.mode) {
          case 1:
            url = 'usps-services/address-verify';
            res = yield call(axios.post, url, payload);       
            break;
          case 2:
            url = 'usps-services/zip-code-lookup';
            res = yield call(axios.post, url, payload);
            break;
          case 3:
            url = 'usps-services/city-state-lookup';
            res = yield call(axios.post, url, payload);
            break;
          case 4:
            url = 'usps-services/track-package/' + payload.userID + '/' + payload.trackingID;
            res = yield call(axios.get, url);
            break;
        }
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