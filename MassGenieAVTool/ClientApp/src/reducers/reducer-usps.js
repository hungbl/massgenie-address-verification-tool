import Immutable from 'immutable';
import * as c from '../constants/constant';

const initialState = Immutable.fromJS({
    mode: 1,
    address1: '',
    address2: '',
    city: '',
    state: '',
    zip4: '',
    zip5: '',
    output: '',
    userID: '',
    trackingID: ''
})

export default (state = initialState, action) => {
    switch (action.type) {
        case c.CHANGE_MODE:
            const userID = state.get('userID');
            return initialState.set('userID', userID)
                                .set('mode', action.payload);
        case c.CHANGE_TEXT_BOX:
            return state.set(action.payload.fieldName, action.payload.value);
        case c.FETCH_OUTPUT:
            return state.set('output', action.payload);
    }
    return state;
}