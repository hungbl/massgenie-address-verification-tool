import { all } from 'redux-saga/effects'
import {sagaCallUSPS} from './saga-usps';

export function* rootSaga(){
	yield all([
		sagaCallUSPS(),
	])
}