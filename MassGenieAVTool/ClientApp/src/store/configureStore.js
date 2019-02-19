import { applyMiddleware, compose, createStore } from 'redux';
import createSagaMiddleware from 'redux-saga';
import { routerMiddleware } from 'react-router-redux';

// import root reducer and saga
import rootReducer from '../reducers/reducer-root';
import {rootSaga} from '../sagas/saga-root';

export default function configureStore (history, initialState) {

  const sagaMiddleware = createSagaMiddleware();
  const middleware = [
    sagaMiddleware,
    routerMiddleware(history)
  ];

  // In development, use the browser's Redux dev tools extension if installed
  const enhancers = [];
  const isDevelopment = process.env.NODE_ENV === 'development';
  if (isDevelopment && typeof window !== 'undefined' && window.devToolsExtension) {
    enhancers.push(window.devToolsExtension());
  }

  const store = createStore(
    rootReducer,
    initialState,
    compose(applyMiddleware(...middleware), ...enhancers)
  );
  sagaMiddleware.run(rootSaga);
  return store;
}
