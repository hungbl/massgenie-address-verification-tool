import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import * as actions from '../actions/action-usps';

class USPS extends React.Component{
  constructor(props){
    super(props);
    this.state = {click: 0};
    this.changeMode = this.changeMode.bind(this);
    this.changeTextBox = this.changeTextBox.bind(this);
    this.callApi = this.callApi.bind(this);
  }
  
  changeMode(mode){
    this.props.changeMode(mode);
  }
  
  changeTextBox(fieldName, e){
    const newTextBox = {
        fieldName: fieldName,
        value: e.target.value
    }
    this.props.changeTextBox(newTextBox);
  }

  callApi(){
    const data = this.props.reducerUSPS.toJS();
    this.props.callApi(data);
  }
  render(){
    const {mode, address1, address2, city, state, zip4, zip5, output, userID} = this.props.reducerUSPS.toJS();
    return(
      <div className="container">
        <div className="alert alert-secondary">
          <div class="btn-toolbar mb-2" role="toolbar">
            <div class="btn-group mr-2" role="group" aria-label="First group">
            {
              mode == 1
              ? <button className="btn btn-md btn-success">Address Verify</button>
              : <button className="btn btn-md btn-secondary" onClick={() => this.changeMode(1)}>Address Verify</button>
            }
            {
              mode == 2
              ? <button className="btn btn-md btn-success">ZIP Code Lookup</button>
              : <button className="btn btn-md btn-secondary" onClick={() => this.changeMode(2)}>ZIP Code Lookup</button>
            }
            {
              mode == 3
              ? <button className="btn btn-md btn-success">City/State Lookup</button>
              : <button className="btn btn-md btn-secondary" onClick={() => this.changeMode(3)}>City/State Lookup</button>
            }
            </div>
            <div class="btn-group" role="group" aria-label="First group">
            {
              mode == 4
              ? <button className="btn btn-md btn-success">Tracking Verify</button>
              : <button className="btn btn-md btn-secondary" onClick={() => this.changeMode(4)}>Tracking Verify</button>
            }
            </div>
          </div>
          <div className="card">
            <div class="card-body">
              <div className="row">
                <div className="col">
                  <input className="form-control mb-2" placeholder='USPS UserID' value={userID} onChange={this.changeTextBox.bind(this, 'userID')}/>
                </div>
              </div>
              {
                mode == 1 || mode == 2
                ? <div className="row">
                    <div className="col">
                      <input className="form-control mb-2" placeholder='Address Line 1' value={address1} onChange={this.changeTextBox.bind(this, 'address1')}/>
                    </div>
                    <div className="col">
                      <input className="form-control mb-2" placeholder='Address Line 2' value={address2} onChange={this.changeTextBox.bind(this, 'address2')}/>
                    </div>
                  </div>
                : null
              }
              {
                mode == 1 || mode == 2
                ? <div className="row">
                    <div className="col">
                      <input className="form-control mb-2" placeholder='City' value={city} onChange={this.changeTextBox.bind(this, 'city')}/>
                    </div>
                    <div className="col">
                      <input className="form-control mb-2" placeholder='State' value={state} onChange={this.changeTextBox.bind(this, 'state')}/>
                    </div>
                  </div>
                : null
              }
              {
                mode == 1 || mode == 3
                ? <div className="row">
                    <div className="col">
                      <input className="form-control mb-2" placeholder='Zip4' value={zip4} onChange={this.changeTextBox.bind(this, 'zip4')}/>
                    </div>
                    <div className="col">
                      <input className="form-control mb-2" placeholder='Zip5' value={zip5} onChange={this.changeTextBox.bind(this, 'zip5')}/>
                    </div>
                  </div>
                : null
              }
            </div>
          </div>
        </div>
      </div>
    );
  }
}

function mapStateToProps (state){
  const {reducerUSPS} = state;
  return {reducerUSPS};
}

function mapDispatchToProps(dispatch){
  return bindActionCreators(actions, dispatch);
}

export default connect( mapStateToProps, mapDispatchToProps )(USPS)
