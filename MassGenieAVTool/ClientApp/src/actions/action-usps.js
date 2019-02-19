import * as c from '../constants/constant';

export function changeMode(mode){
	return{
		type: c.CHANGE_MODE,
		payload: mode
	};
}

export function changeTextBox(newTextBox){
	return{
		type: c.CHANGE_TEXT_BOX,
		payload: newTextBox
	}
}

export function callApi(data){
	return{
		type: c.CALL_API,
		payload: data
	}
}

export function fetchOutput(data){
	return{
		type: c.FETCH_OUTPUT,
		payload: data
	}
}