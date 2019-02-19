import {combineReducers} from 'redux';
import {routerReducer} from 'react-router-redux';
import ReducerUSPS from './reducer-usps';

const rootReducer = combineReducers({
    routing: routerReducer,
    reducerUSPS: ReducerUSPS
});

export default rootReducer;