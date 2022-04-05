import React, { Component } from 'react';
import logo from '../assets/logo.png';
import { NavLink } from 'react-router-dom';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);
    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true,
      links: [
        { 
          id: 1, 
          name: "Home", 
          to: "/", 
          className: "transition ease-in-out md:p-4 py-2 block hover:text-red-600 duration-500"
        },
        { 
          id: 2, 
          name: "Fetch Data", 
          to: "/fetch-data", 
          className: "transition ease-in-out md:p-4 py-2 block hover:text-red-600 duration-500"
        },
        {
          id: 3,
          name: "Reports",
          to: "/reports",
          className: "transition ease-in-out md:p-4 py-2 block hover:text-red-600 duration-500"
        }
      ]
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed,
    });
  };

  navLinkClass({isActive}, classname) {
    return isActive ? classname + " underline underline-offset-4" : classname
  }

  render () {
    const { links } = this.state;
    return (
      <header>
        <nav className="flex flex-col items-center py-4 md:py-2 bg-white text-lg text-gray-700 px-4">
          <div className="w-16">
            <img src={logo} alt="logo" />
          </div>
          <div className="w-full md:flex md:items-center md:w-auto" id='menu'>
            <ul className='text-base pt-4 md:flex md:justify-between md:pt-0'>
              {links.map(link => (
                <li key={link.id}>
                  <NavLink className={({isActive}) => this.navLinkClass({isActive}, link.className)} to={link.to}>{link.name}</NavLink>
                </li>
              ))}
            </ul>
          </div>
        </nav>
      </header>
    );
  }
}
