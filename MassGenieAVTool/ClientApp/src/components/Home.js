import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import * as actions from '../actions/action-usps';

class Home extends React.Component{
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
      <div>
        <div className="mgTool">
          <div className="mgContent">
          {
            mode == 1
            ? <button className="btn btn-lg mgSpan mgBtn btn-success">Address Verify</button>
            : <button className="btn btn-lg mgSpan mgBtn btn-secondary" onClick={() => this.changeMode(1)}>Address Verify</button>
          }
          {
            mode == 2
            ? <button className="btn btn-lg mgSpan mgBtn btn-success">ZIP Code Lookup</button>
            : <button className="btn btn-lg mgSpan mgBtn btn-secondary" onClick={() => this.changeMode(2)}>ZIP Code Lookup</button>
          }
          {
            mode == 3
            ? <button className="btn btn-lg mgSpan mgBtn btn-success">City/State Lookup</button>
            : <button className="btn btn-lg mgSpan mgBtn btn-secondary" onClick={() => this.changeMode(3)}>City/State Lookup</button>
          }
          </div>
        </div>
        <div className="mgToolBody">
          <div className="container-fluid innerBodyDiv">
            <div className="row-fluid center">
              <div className="width80 mainContent">
                <div className="form-group">
                  <input className="form-control margin-bottom-10" placeholder='USPS UserID' value={userID} onChange={this.changeTextBox.bind(this, 'userID')}/>
                </div>
                <div className="form-group">
                  <div className="width40 margin-right-40">
                  {
                    mode == 1 || mode == 2
                    ? <input className="form-control margin-bottom-10" placeholder='Address Line 1' value={address1} onChange={this.changeTextBox.bind(this, 'address1')}/>
                    : null
                  }
                  {
                    mode == 1 || mode == 2
                    ? <input className="form-control margin-bottom-10" placeholder='City' value={city} onChange={this.changeTextBox.bind(this, 'city')}/>
                    : null
                  }
                  {
                    mode == 1 || mode == 3
                    ? <input className="form-control margin-bottom-10" placeholder='Zip5' value={zip5} onChange={this.changeTextBox.bind(this, 'zip5')}/>
                    : null
                  }
                  </div>
                  <div className="width40 margin-left-40">
                  {
                    mode == 1 || mode == 2
                    ? <input className="form-control margin-bottom-10" placeholder='Address Line 2' value={address2} onChange={this.changeTextBox.bind(this, 'address2')}/>
                    : null
                  }
                  {
                    mode == 1 || mode == 2
                    ? <input className="form-control margin-bottom-10" placeholder='State' value={state} onChange={this.changeTextBox.bind(this, 'state')}/>
                    : null
                  }
                  {
                    mode == 1 || mode == 3
                    ? <input className="form-control margin-bottom-10" placeholder='Zip4' value={zip4} onChange={this.changeTextBox.bind(this, 'zip4')}/>
                    : null
                  }
                  </div>
                </div>
                <div className="form-group width100 right">
                  <button className="btn btn-sm mgFormBtn btn-success" onClick={this.callApi}>Run</button>
                </div>
                <div className="form-group">
                  <label>Result:</label>
                  <textarea className="form-control mgTextArea" type="text" readOnly="true" value={output}/>
                </div>
              </div>
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

export default connect( mapStateToProps, mapDispatchToProps )(Home)
