/**
 * 
 */
package com.example.cashregister.model;

/**
 * @author harithakavuri
 *
 */
public class Amount {
	
	private long owed;
	private long paid;
	
	private String msg;
	
	public String getMsg() {
		return msg;
	}
	public void setMsg(String msg) {
		this.msg = msg;
	}
	public long getOwed() {
		return owed;
	}
	public void setOwed(long owed) {
		this.owed = owed;
	}
	public long getPaid() {
		return paid;
	}
	public void setPaid(long paid) {
		this.paid = paid;
	}
	
}
