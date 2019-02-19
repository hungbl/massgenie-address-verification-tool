import React from 'react';
import { Container, Navbar, NavbarBrand} from 'reactstrap';
import { Link } from 'react-router-dom';

export default class NavMenu extends React.Component {
  constructor (props) {
    super(props);

    this.toggle = this.toggle.bind(this);
    this.state = {
      isOpen: false
    };
  }
  toggle () {
    this.setState({
      isOpen: !this.state.isOpen
    });
  }
  render () {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow mb-3" light >
          <Container>
            <NavbarBrand tag={Link} to="/">Shipping Services</NavbarBrand>
            <NavbarBrand tag={Link} to="/usps-services">USPS Services</NavbarBrand>
            <NavbarBrand tag={Link} to="/ups-services">UPS Services</NavbarBrand>
            <NavbarBrand tag={Link} to="/dhl-services">DHL Services</NavbarBrand>
            <NavbarBrand tag={Link} to="/fedex-services">FEDEX Services</NavbarBrand>
          </Container>
        </Navbar>
      </header>
    );
  }
}
