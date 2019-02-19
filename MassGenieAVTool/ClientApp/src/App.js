import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import USPS from './components/usps';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route exact path='/usps-services' component={USPS} />
  </Layout>
);
