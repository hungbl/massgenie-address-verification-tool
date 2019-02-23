import Immutable from 'immutable';
import * as c from '../constants/constant';

const initialState = Immutable.fromJS({
    mode: 1,
    address1: '1204 Waverly Way',
    address2: '',
    city: 'Longwood',
    state: 'ME',
    zip4: '',
    zip5: '32750',
    output: '',
    userID: '968MASSG7302',
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